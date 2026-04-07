using System;

public static class SharedData
{
    public static double[] CurrentMap = null;
    public stattic bool Running=false;
    public static readonly object Maplock=new object();//prueba
}
