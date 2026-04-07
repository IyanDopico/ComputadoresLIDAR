using System;

public static class SharedData
{
    public static double[] currentMap = null;
    public stattic bool running=false;
    public static readonly object Maplock=new object();
}
