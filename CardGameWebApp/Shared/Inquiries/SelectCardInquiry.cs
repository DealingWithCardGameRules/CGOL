﻿using System;

namespace CardGameWebApp.Shared.Inquiries
{
    public class SelectCardInquiry
    {
        public Guid CorrespondenceId { get; }
        public string Collection { get; }
        public string[]? RequiredTags { get; }

        public SelectCardInquiry(Guid correspondenceId, string collection, string[]? requiredTags = null)
        {
            CorrespondenceId = correspondenceId;
            Collection = collection;
            RequiredTags = requiredTags;
        }
    }
}
