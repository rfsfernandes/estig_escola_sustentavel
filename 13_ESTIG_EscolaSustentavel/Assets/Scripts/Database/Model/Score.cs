namespace Database.Model
{
    public class Score
    {
        private int _id;
        private string _username;
        private int _score;
        private int _timepassed;
        private long _createdAt;
        private int _lampId;
        private int _panelsId;
        private int _sensorsId;

        public Score(int id, string username, int score, int timepassed, long createdAt, int lampId, int panelsId, int sensorsId)
        {
            _id = id;
            _username = username;
            _score = score;
            _timepassed = timepassed;
            _createdAt = createdAt;
            _lampId = lampId;
            _panelsId = panelsId;
            _sensorsId = sensorsId;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public int Score1
        {
            get => _score;
            set => _score = value;
        }

        public int Timepassed
        {
            get => _timepassed;
            set => _timepassed = value;
        }

        public long CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public int LampId
        {
            get => _lampId;
            set => _lampId = value;
        }

        public int PanelsId
        {
            get => _panelsId;
            set => _panelsId = value;
        }

        public int SensorsId
        {
            get => _sensorsId;
            set => _sensorsId = value;
        }
    }
}