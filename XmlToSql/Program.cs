﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlToSql.XmlHelper;
using static System.Net.Mime.MediaTypeNames;

namespace XmlToSql
{
    class Program
    {
        private static Xmlhelper xmlHelper;
        //private static DBHelper dbHelper;

        static void Main(string[] args)
        {

            initialize();
            start();
            Console.ReadKey();
        }

        private static void initialize()
        {
            xmlHelper = new Xmlhelper();
            //dbHelper = new DBHelper();
        }

        private static void start()
        {
            //ConnectionState connectionState = dbHelper.connect();
            //if (connectionState == ConnectionState.Open)
            //{
            //    Console.WriteLine("Connected to DB");
            //}
            //else
            //{
            //    Console.WriteLine("Has some error while connectig to DB. The data will not be saved to DB");
            //    Console.ReadKey();
            //}

            xmlHelper.process();

        }

    }
}
