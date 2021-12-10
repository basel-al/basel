class Color
{
    private int red;
    public int Red { get => red; set => red = value; }
    private int green;
    public int Green { get => green; set => green = value; }
    private int blue;
    public int Blue { get => blue; set => blue = value; }
    private int alpha;
    public int Alpha { get => alpha; set => alpha = value; }
    public Color(int thered, int thegreen, int theblue, int thealpha)
    {
        red = thered;
        green =thegreen;
        Blue=theblue;
        alpha=thealpha;
    }
    public Color(int thered, int thegreen, int theblue)
    {
        red = thered;
        green = thegreen;
        Blue = theblue;
        alpha = 255;
    }
    public int Grayscale()
    {
        return (red+green+blue)/3;
    }

}