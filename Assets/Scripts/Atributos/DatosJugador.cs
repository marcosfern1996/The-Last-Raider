[System.Serializable]

public class DatosJugador
{
    public int cantidadDeBalasPistola;
    public int cantidadDeCargadores9mm;
    public int cantidadDeCargadoresEscopeta;
    public int cantidadDeBalasEscopeta;

    public float[] posicionJugador=new float[3];
    public float saludActual;


    public DatosJugador(MoverPersonajeAPie datos)
    {
        saludActual = MoverPersonajeAPie.instance.saludPersanjeIndi;
        cantidadDeBalasPistola = AtributosArmas.cantidadBalasEscopeta;
        cantidadDeCargadores9mm = AtributosArmas.cantidadDeCargadores9mm;
        cantidadDeCargadoresEscopeta = AtributosArmas.cantidadDeCargardoresEscopetas;
        cantidadDeBalasEscopeta = AtributosArmas.cantidadBalasEscopeta;
        posicionJugador[0]= MoverPersonajeAPie.instance.transform.position.x;
        posicionJugador[1]= MoverPersonajeAPie.instance.transform.position.y;
        posicionJugador[2]= MoverPersonajeAPie.instance.transform.position.z;
    }

}
