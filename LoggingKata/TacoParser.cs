namespace LoggingKata
{
    
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            
            string[] cells = line.Split(',');

            
            if (cells.Length < 3)
            {
                
                logger.LogError("Error, array length less than 3");
                return null; 
            }

            
            double lat = double.Parse(cells[0]);
            
            
            
            double lon = double.Parse(cells[1]);
            
            
            
            string name = cells[2];


            
            Point pointInstance = new Point();
            pointInstance.Latitude = lat;
            pointInstance.Longitude = lon;


            
            TacoBell tacoInstance = new TacoBell();
            tacoInstance.Name = name;
            tacoInstance.Location = pointInstance;

            

            return tacoInstance;
        }
    }
}
