using CardGameWebApp.Shared.DTOs;
using System;
using System.Collections.Generic;

namespace CardGameWebApp.Shared.Inquiries
{
    public class SelectCardInquiry
    {
        public Guid CorrespondenceId { get; }
        public IEnumerable<CardRefDTO> Selection { get; }
        public bool Required { get; }

        public SelectCardInquiry(Guid correspondenceId, IEnumerable<CardRefDTO> selection, bool required = true)
        {
            CorrespondenceId = correspondenceId;
            Selection = selection;
            Required = required;
        }
    }
}
