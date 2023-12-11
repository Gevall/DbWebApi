namespace DbWebApi.Model
{
    public class TripsModel
    {
        public string Manager { get; set; } = null!;
        public string LoadCrm { get; set; } = null!;
        public string Docs { get; set; } = null!;
        public string ReadySort { get; set; } = null!;
        public DateTime DateTrip { get; set; }
        public string? Specialist { get; set; }
    }
}
