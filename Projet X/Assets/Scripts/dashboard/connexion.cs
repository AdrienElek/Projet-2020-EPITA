using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text;

//ajout de la librairie Mysql dans les références

public class connexion : MonoBehaviour
{
    //tentative de connexion à une base de données spécifiée
     void sqlconnect (string host,int port,string database,string username, string password)
    {
        string connstr = "Server=" + host + ";Database=" + database + ";port=" + port + ";User id=" + username + ";password=" + password;
        MySqlConnection conn = new MySqlConnection(connstr);
        try
        {
            conn.Open();
            Debug.Log("connexion à la base de donnée réussie");
        }
        catch (MySqlException e)
        {
            Debug.Log("la connexion à la base de donnée à échouée");
            Debug.Log("cause de l'échec:"+ "\n" + e.ToString());
        }
    }
 /*   bool sendscore()
    {
        bool res = true;
        try
        {
            MySqlCommand cmd = new MySqlCommand();
        }
        catch (MySqlException e) {
            Debug.Log("sending failed because:"+"\n"+e.ToString());
            res = false;
        }
        return res;
    } */

    private void Awake()
    {
        sqlconnect("localhost", 8090, "dashboard", "root", "");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!PlayerStat.isAlive)
        {

        }*/
    }
}
