﻿namespace Business.Dtos.Responses.Survey
{
	public class DeletedSurveyResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FormUrl { get; set; }
    }
}
