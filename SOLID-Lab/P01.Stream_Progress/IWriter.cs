namespace P01.Stream_Progress
{
    public interface IWriter
    {
        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}