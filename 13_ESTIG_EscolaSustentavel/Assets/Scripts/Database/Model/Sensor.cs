namespace Database
{
    public class Sensor
    {
        private int _id;
        private string _name;
        private int _unitCount;
        private double _unitPrice;
        private int _points;
        private int _energyBefore;
        private int _reach;
        private int _angle;
        private int _energyAfter;
        private string _infoText;
        private string _positiveText;
        private string _negativeText;

        public Sensor(int id, string name, int unitCount, double unitPrice, int points, int energyBefore, int reach, int angle, int energyAfter, string infoText, string positiveText, string negativeText)
        {
            _id = id;
            _name = name;
            _unitCount = unitCount;
            _unitPrice = unitPrice;
            _points = points;
            _energyBefore = energyBefore;
            _reach = reach;
            _angle = angle;
            _energyAfter = energyAfter;
            _infoText = infoText;
            _positiveText = positiveText;
            _negativeText = negativeText;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int UnitCount
        {
            get => _unitCount;
            set => _unitCount = value;
        }

        public double UnitPrice
        {
            get => _unitPrice;
            set => _unitPrice = value;
        }

        public int Points
        {
            get => _points;
            set => _points = value;
        }

        public int EnergyBefore
        {
            get => _energyBefore;
            set => _energyBefore = value;
        }

        public int Reach
        {
            get => _reach;
            set => _reach = value;
        }

        public int Angle
        {
            get => _angle;
            set => _angle = value;
        }

        public int EnergyAfter
        {
            get => _energyAfter;
            set => _energyAfter = value;
        }

        public string InfoText
        {
            get => _infoText;
            set => _infoText = value;
        }

        public string PositiveText
        {
            get => _positiveText;
            set => _positiveText = value;
        }

        public string NegativeText
        {
            get => _negativeText;
            set => _negativeText = value;
        }
    }
}