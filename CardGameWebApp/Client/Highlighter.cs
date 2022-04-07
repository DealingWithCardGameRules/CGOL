using CardGameWebApp.Shared.DTOs;
using dk.itu.game.msc.cgdl.LanguageParser.Lexers;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System.Collections.Generic;
using System.Text;

namespace CardGameWebApp.Client
{
    public class Highlighter
    {
        private readonly Lexer lexer;
        public IDictionary<string, ConceptDTO> KnownConcept { get; set; }

        public Highlighter()
        {
            lexer = new LexerFactory().CreateTolerant();
            KnownConcept = new Dictionary<string, ConceptDTO>();
        }
        
        public string Highlight(string input)
        {
            var output = new StringBuilder();
            foreach (var token in lexer.Tokenize(input))
            {
                if (token is SequenceTerminator)
                {
                    output.Append("<br \\>");
                }
                else if (token is StringLiteral literal)
                {
                    output.Append($"<span class=\"token symbol\">\"</span><span class=\"token {token.Type}\">{literal.Value}</span><span class=\"token symbol\">\"</span>");
                }
                else if (token is Symbol)
                {
                    output.Append(token.RawValue);
                }
                else if (KnownConcept.ContainsKey(token.RawValue))
                {
                    var knowledge = KnownConcept[token.RawValue];
                    output.Append($"<span class=\"token {token.Type}\" data-placement=\"top\" data-toggle=\"tooltip\" data-html=\"true\" title=\"");
                    output.Append("<p class='conceptinfo mb-0'>");
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
                else
                {
                    output.Append($"<span class=\"token {token.Type}\">{token.RawValue}</span>");
                }
            }
            var debug = output.ToString();
            return debug;
        }
    }
}
