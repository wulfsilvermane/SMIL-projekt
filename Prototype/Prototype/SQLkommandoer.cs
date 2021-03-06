﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Prototype
{
    class SQLkommandoer
    {
        public static string HentPatient()
        {
            string navn;
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            SqlDataReader reader;
            Command.Connection = conn;
            Command.CommandText = "";
            Command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            reader = Command.ExecuteReader();
            navn = reader.GetString(1);    
            conn.Close();
            return navn;
        }
        public static void IndsaetBynavn(int postnr, string navn)
        {
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            //SqlDataReader reader;
            Command.Connection = conn;
            Command.CommandText = "SPpost";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@postNr", postnr);
            Command.Parameters.AddWithValue("@bynavn", navn);
            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();
        }
        public static Patient FindPatient(string CPR)
        {
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            Command.Connection = conn;
            Command.CommandText = "SPpatientDataEnkeltPatient";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@CPRnr", CPR);
            Patient patient = new Patient();
            conn.Open();
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                patient = new Patient(reader.GetInt32(0),//Patient ID
                    reader.GetString(1),//CPR
                    reader.GetString(2),//Fornavn
                    reader.GetString(3),//Efternavn
                    reader.GetString(4),//Addresse
                    reader.GetInt32(5),//Post Nummer
                    reader.GetString(6),//Bynavn
                    reader.GetString(7),//Tlf
                    reader.GetString(8),//Mobil
                    reader.GetString(9),//Email
                    reader.GetString(10),//Noter
                    reader.GetInt32(11)//Sikrings gruppe
                    );
            }

            conn.Close();
            return patient;
        }
        public static void OpdaterPatient(Patient patient)
        {
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            Command.Connection = conn;
            Command.CommandText = "SPopdaterPatientOplysninger";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@patientID",patient.patientid);
            Command.Parameters.AddWithValue("@CPRnr", patient.cprnummer);
            Command.Parameters.AddWithValue("@fornavn",patient.fornavn);
            Command.Parameters.AddWithValue("@efternavn",patient.efternavn);
            Command.Parameters.AddWithValue("@adresse",patient.adresse);
            Command.Parameters.AddWithValue("@postNr",patient.postnummer);
            Command.Parameters.AddWithValue("@telefonnr",patient.telefon);
            Command.Parameters.AddWithValue("@mobil",patient.mobil);
            Command.Parameters.AddWithValue("@email",patient.email);
            Command.Parameters.AddWithValue("@noter",patient.bemærkninger);
            Command.Parameters.AddWithValue("@sikringsGruppe", "1"); // MIDLERTIDIG
            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public static void OpretPatient(Patient patient)
        {
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            Command.Connection = conn;
            Command.CommandText = "SPopretPatient";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@CPRnr", patient.cprnummer);
            Command.Parameters.AddWithValue("@fornavn", patient.fornavn);
            Command.Parameters.AddWithValue("@efternavn", patient.efternavn);
            Command.Parameters.AddWithValue("@adresse", patient.adresse);
            Command.Parameters.AddWithValue("@postNr", patient.postnummer);
            Command.Parameters.AddWithValue("@telefonr", patient.telefon);
            Command.Parameters.AddWithValue("@mobil", patient.mobil);
            Command.Parameters.AddWithValue("@email", patient.email);
            Command.Parameters.AddWithValue("@noter", patient.bemærkninger);
            Command.Parameters.AddWithValue("@sikringsGruppe", "1"); // MIDLERTIDIG
            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();
        }
        public static void SletPatient(Patient patient)
        {
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            Command.Connection = conn;
            Command.CommandText = "SPsletPatient";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@patientId", patient.patientid);
            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Reservation> HentReservation(DateTime starttid, DateTime sluttid)
        {
            List<Reservation> res = new List<Reservation>();
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            Command.Connection = conn;
            Command.CommandText = "SPseAlleReservationerIudvalgtTidsrum";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@startDato", starttid.Date);
            Command.Parameters.AddWithValue("@slutDato", sluttid.Date);
            conn.Open();
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(6))
                    res.Add(new Reservation(reader.GetInt32(0),//Res ID
                        reader.GetDateTime(1),//dato
                        reader.GetInt32(3),//lokale navn
                        reader.GetString(4),//fornavn
                        reader.GetString(5),//efternavn
                        reader.GetString(2),//behandling
                        reader.GetString(6),//speciale
                        reader.GetInt32(7)//Længde
                        ));
                    else
                        res.Add(new Reservation(reader.GetInt32(0),//Res ID
                        reader.GetDateTime(1),//dato
                        reader.GetInt32(3),//lokale navn
                        reader.GetString(4),//fornavn
                        reader.GetString(5),//efternavn
                        reader.GetString(2),//behandling
                        reader.GetInt32(7)//Længde
                        ));
                }
            }
            conn.Close();
            return res;
        }
        public static void NyReservation(Reservation reservation,Behandling behandling, int special)
        {
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            Command.Connection = conn;
            Command.CommandText = "SPopretReservation";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@reservationsDato", reservation.startdato);
            Command.Parameters.AddWithValue("@reservationstid", reservation.starttid);
            Command.Parameters.AddWithValue("@lokaleID", reservation.lokaleid);
            Command.Parameters.AddWithValue("@behandlingsID", behandling.BehandlingsID);
            Command.Parameters.AddWithValue("@reservationslængde", reservation.længde);
            Command.Parameters.AddWithValue("@special", special);
            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Behandling> HentPatientBehandlinger(Patient patient)
        {
            List<Behandling> Behandlinger = new List<Behandling>();
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            Command.Connection = conn;
            Command.CommandText = "SPseAllePatientBehandlinger";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@patientID", patient.patientid);
            conn.Open();
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                while (reader.Read())
                    Behandlinger.Add(new Behandling(
                        reader.GetInt32(0),//BehandlingsID
                        reader.GetString(1)//Beskrivelse
                        ));
            }
            conn.Close();
            return Behandlinger;
        }
        public static void OpretBehandling(Patient patient,string behandling)
        {
            SqlConnection conn = new SqlConnection(Program.SQLforbindelse);
            SqlCommand Command = new SqlCommand();
            Command.Connection = conn;
            Command.CommandText = "SPOpretBehandling";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@patientID", patient.patientid);
            Command.Parameters.AddWithValue("@beskrivelse", behandling);
            conn.Open();
            Command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
