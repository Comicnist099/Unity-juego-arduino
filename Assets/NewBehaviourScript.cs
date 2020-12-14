using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;


public class NewBehaviourScript : MonoBehaviour
{
    public int Enemigo = 0;
    public static bool LeDio = false;
    public SerialPort stream = new SerialPort("COM3", 9600);
    public float gradosy;
    public float gradosX;
    public float sensibilidad = 1.5f;
    public float rapidez = 0.5f;
    public float rango = .1550000f;
    public float rango_cero = 0.0f;
    public int puntos=100;

    public bool mientras = false;
    // Start is called before the first frame update


    public string ReadFromArduino(int timeout = 0)
    {
        stream.ReadTimeout = timeout;
        try
        {
            return stream.ReadLine();
        }
        catch (TimeoutException e)
        {
            return null;
        }
    }
    public void WriteToArduino(string message)
    {
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }
    void Start()
    {
        try
        {
            stream.Open();


            stream.ReadTimeout = 5000;

        }
        catch (Exception e)
        {
            Debug.Log("Could not open serial port: " + e.Message);
        }

    }

    void OnCollisionEnter(Collision a)
    {
        if (LeDio)
        {

            if (a.gameObject.CompareTag("Ghost"))
            {
                WriteToArduino("PING");
                Destroy(a.gameObject);
                Texto.score += puntos;
                Enemigo++;
                Debug.Log("LOL");
            }
            if (a.gameObject.CompareTag("Plataforma"))
            {
                WriteToArduino("PING");
                Destroy(a.gameObject);
                Texto.score += puntos+100;
                Enemigo++;
                Debug.Log("LOL");
            }

        }

    }


    void Update()
    {
        try
        {
            if (stream.IsOpen)
            {


                //float gradosX = (float)control->GetState().Gamepad.sThumbRX / 32767.0;
                //float gradosY = (float)control->GetState().Gamepad.sThumbRY / 32767.0;
                //print(stream.ReadLine());


                if (Enemigo == 15)
                {
                    WriteToArduino("LAMPARA");
                    WriteToArduino("MUSICA");
                    Enemigo =0;

                }
                string reserv = stream.ReadLine();
                string Primera = reserv.Substring(0, 1);
                if (Primera == "x")
                {
                    string resultadox = reserv.Replace("x", "");
                    int resultadoInt_x = Int32.Parse(resultadox);

                    gradosX = (int)resultadoInt_x / 3276.70f;



                }
                else if (Primera == "y")
                {
                    string resultadoy = reserv.Replace("y", "");
                    int resultadoInt_y = Int32.Parse(resultadoy);
                    gradosy = (int)resultadoInt_y / 3276.70f;


                }
                if (Primera == "S")
                {
                    LeDio = true;
                }
                else
                {
                    LeDio = false;
                }


                if (gradosX > rango)
                {
                    gameObject.transform.Translate(((gradosX-.27f) * rapidez), 0, 0);

                }
                else
                {
                    if (!mientras)
                        gameObject.transform.Translate(0, 0, 0);
                }


                if (gradosy > rango)
                {
                    gameObject.transform.Translate(0, (gradosy-.27f )* rapidez, 0);
                }
                else
                {
                    if (!mientras)
                        gameObject.transform.Translate(0, 0, 0);
                }


                /////////////////////////////////////////
                if (gradosX == 0.0f)
                {
                    gameObject.transform.Translate((gradosX - .04f) * rapidez, 0, 0);
                }
                else
                {
                    if (!mientras)
                        gameObject.transform.Translate(0, 0, 0);
                }


                if (gradosy == 0.0f)
                {
                    gameObject.transform.Translate(0, (gradosy - .04f) * rapidez, 0);
                }
                else
                {
                    if (!mientras)
                        gameObject.transform.Translate(0, 0, 0);
                }






                /*if (reservInt > 05101 && reservInt < 5105101)
                {
                    gameObject.transform.Translate(.03f,0,0);

                }*/
            }
        }
        catch (System.Exception ex)
        {
            ex = new System.Exception();
        }
    }


}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        RandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = gameObject.transform.position + direction * speed;
    }

    public void RandomDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(.2f, 1f), 0);
    }
    public void DirectionChanger(Vector3 _dir)
    {
        direction = new Vector3(direction.x + _dir.x, direction.y + _dir.y, 0);
    }
}*/