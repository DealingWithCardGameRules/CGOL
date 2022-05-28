using CardGameWebApp.Shared.DTOs;
using dk.itu.game.msc.cgol.Representation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace CardGameWebApp.Server.Controllers
{
    [ApiController]
    [Route("Sessions/{id:Guid}/[controller]")]
    public class ConceptsController : Controller
    {
        private readonly SessionService session;

        public ConceptsController(SessionService session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        [HttpGet]
        public IEnumerable<ConceptDTO> Index(Guid id)
        {
            var current = session.GetSession(id);
            foreach (var type in current.Interpreter.SupportedTypes)
            {
                var ctor = type.GetConstructors().FirstOrDefault();
                yield return new ConceptDTO
                {
                    Name = type.Name,
                    Type = GetMessageType(type),
                    Parameters = GetParameters(ctor),
                    Description = ctor.GetConceptDescription()
                };
            }
        }

        private IEnumerable<ActionParameterDTO> GetParameters(ConstructorInfo ctor)
        {
            if (ctor == null)
                yield break;

            foreach (var parameter in ctor.GetParameters())
            {
                yield return new ActionParameterDTO
                {
                    Name = parameter.Name,
                    Type = TypeToString(parameter.ParameterType),
                    Required = !parameter.IsOptional
                };
            }
        }

        private string TypeToString(Type type)
        {
            if (type == typeof(int))
                return ActionParameterDTO.TYPE_NUMBER;
            if (type == typeof(string))
                return ActionParameterDTO.TYPE_STRING;
            return $"Unsupported type ({type.Name})";
        }

        private string GetMessageType(Type concept)
        {
            if (typeof(ICommand).IsAssignableFrom(concept))
                return ConceptDTO.TYPE_COMMAND;
            if (typeof(IQuery<>).IsAssignableFrom(concept))
                return ConceptDTO.TYPE_QUERY;
            if (typeof(IEvent).IsAssignableFrom(concept))
                return ConceptDTO.TYPE_EVENT;
            return String.Empty;
        }
    }
}
