namespace HP_Player_Console.Application.Common
{
    public class ResultData
    {
        public bool success { get; set; } = true;
        public object Errors { get; set; }
        public object Results { get; set; }
    }
}
