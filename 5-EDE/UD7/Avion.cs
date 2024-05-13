
public class avion             {	
	public avion (float ALTURA, float 
    vel,  float combustible, int o)	{
	this.ALTURA = ALTURA;this.v = vel;
	this.combustible = combustible;this.o = o;	}
	
			public float Altura 	{		get { return ALTURA;}
			}
	
					public int Orientacion
					{
						get { 
			return
				o;}
	}
	public void Virar(int 
	  grados){
		o= (o + 
		    grados)%360;consumir_fuel (grados * 0.1);
	}

	public float Combustible
	{get{return combustible;}}
//Metodos que sirve para ascender los metros indicados
public void a(float M) //M son los metros
{
ALTURA=ALTURA+M;consumir_fuel(M*0.3);		
}
	//Metodos que sirve para descender los metros indicados
	public void m(float 
	                      metros)
	{
		ALTURA=ALTURA-metros;
		if (ALTURA<0)		
		ALTURA=0;		
	}	
	private float ALTURA;
	private float v; // Velocidad del avion
	private float combustible;private int o;	
private void consumir_fuel (float litros)
{		combustible=combustible-litros;
	if (combustible<0)
combustible = 0;		
}
	
		}
