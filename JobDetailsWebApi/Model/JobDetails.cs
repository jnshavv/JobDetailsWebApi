namespace JobDetailsWebApi.Model
{
    public class JobDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobRole { get; set; }
        public int TotalExperience { get; set; }
        public decimal CurrentCtc { get; set; }
        public decimal ExpectedCtc { get; set; }
        public string ReasonForJobChange { get; set; }
        public int NoticePeriod { get; set; }
        public string CurrentCity { get; set; }
        public string Pincode { get; set; }
        public DateTime Date { get; set; }
        public string UploadCv { get; set; }

    }
}
