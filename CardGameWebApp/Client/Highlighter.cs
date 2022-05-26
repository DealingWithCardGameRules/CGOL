using CardGameWebApp.Shared.DTOs;
using dk.itu.game.msc.cgol.Parser.Lexers;
using dk.itu.game.msc.cgol.Parser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGameWebApp.Client
{
    public class Highlighter
    {
        private readonly Lexer lexer;
        public IDictionary<string, ConceptDTO> KnownConcept { get; set; }
        public string? Suggestion { get; private set; }
        public Highlighter()
        {
            lexer = new LexerFactory().CreateTolerant();
            KnownConcept = new Dictionary<string, ConceptDTO>();
        }
        
        public string Highlight(string input, long cursorPosition = 0)
        {
            Suggestion = null;
            var output = new StringBuilder();
            var position = 0;
            foreach (var token in lexer.Tokenize(input))
            {
                if (token is SequenceTerminator)
                    position++;
                else
                    position += token.RawValue.Length;

                var currentPosition = position == cursorPosition;

                if (token is SequenceTerminator)
                {
                    output.Append("<br \\>");
                }
                else if (token is StringLiteral literal)
                {
                    output.Append($"<span class=\"token symbol\">\"</span><span class=\"token {token.Type}\">{literal.Value}</span><span class=\"token symbol\">\"</span>");
                }
                else if (token is Tabulator)
                {
                    output.Append($"<span class=\"token tabulator\">{token.RawValue}</span>");
                }
                else if (token is Symbol)
                {
                    output.Append(token.RawValue);
                }
                else if (KnownConcept.ContainsKey(token.RawValue))
                {
                    var knowledge = KnownConcept[token.RawValue];
                    output.Append($"<span class=\"token {token.Type} recognized\" data-placement=\"top\" data-toggle=\"tooltip\" data-html=\"true\" title=\"");
                    output.Append("<p class='conceptinfo mb-0'>");

                    if (knowledge.Type.Equals(ConceptDTO.TYPE_COMMAND))
                        output.Append("<i class='text-primary fa-solid fa-circle-exclamation me-1'></i>");
                    else if (knowledge.Type.Equals(ConceptDTO.TYPE_EVENT))
                        output.Append("<i class='text-danger fa-solid fa-calendar-check me-1'></i>");
                    else
                        output.Append("<i class='text-info fa-solid fa-circle-question me-1'></i>");

                    output.Append($"<strong>{knowledge.Name}</strong>");
                    foreach (var parameter in knowledge.Parameters)
                    {
                        output.Append(' ');
                        string name = "<span class='text-muted'>";
                        if (parameter.Type == ActionParameterDTO.TYPE_NUMBER)
                            name += "<i class='fa-solid fa-hashtag fa-2xs'></i>";
                        else if (parameter.Type == ActionParameterDTO.TYPE_STRING)
                            name += "<i class='fa-solid fa-t fa-2xs'></i>";
                        else
                            name += "<i class='fa-solid fa-question fa-2xs'></i>";
                        name += "</span>";

                        name += $"<em>{parameter.Name}</em>";
                        output.Append(parameter.Required ? name : $"[{name}]");
                    }
                    output.Append("</p>");
                    if (!string.IsNullOrWhiteSpace(knowledge.Description))
                        output.Append($"<p class='conceptinfo mb-0 text-info'><i>{knowledge.Description}</i></p>");

                    output.Append($"\">{token.RawValue}</span>");
                }
                else if (token is Concept concept)
                {
                    output.Append($"<span class=\"token {concept.Type} unrecognized\">{token.RawValue}</span>");
                    if (currentPosition)
                    {
                        UpdateSuggestConcept(token.RawValue);
                        output.Append($"<span class='text-muted'>{Suggestion ?? ""} </span>");
                    }
                }
                else
                {
                    output.Append($"<span class=\"token {token.Type}\">{token.RawValue}</span>");
                }
            }
            var debug = output.ToString();
            return debug;
        }

        private void UpdateSuggestConcept(string currentValue)
        {
            Suggestion = KnownConcept
                .Where(c => c.Key.StartsWith(currentValue, StringComparison.OrdinalIgnoreCase))
                .Select(c => c.Key.Substring(currentValue.Length))
                .FirstOrDefault();
        }
    }
}
