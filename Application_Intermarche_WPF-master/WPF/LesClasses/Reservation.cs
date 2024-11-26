using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    public class Reservation
    {
        private int numReservation;
        private int numAssurance;
        private int numClient;
        private DateTime dateReservation;
        private DateTime dateDebutReservation;
        private DateTime dateFinReservation;
        private decimal moantantReservation;
        private string forfaitKm;



        public int NumReservation
        {
            get
            {
                return numReservation;
            }

            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("Attention le numéro de réservation doit etre supérieur à 0"); }
                numReservation = value;
            }
        }

        public int NumAssurance
        {
            get
            {
                return numAssurance;
            }

            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("Attention le numéro d'assurance doit etre supérieur à 0"); }
                numAssurance = value;
            }
        }

        public int NumClient
        {
            get
            {
                return numClient;
            }

            set
            {
                if (value <= 0) { throw new ArgumentOutOfRangeException("Attention le numéro du client  doit etre supérieur à 0"); }
                numClient = value;
            }
        }

        public DateTime DateReservation
        {
            get
            {
                return dateReservation;
            }

            set
            {
                dateReservation = value;
            }
        }

        public DateTime DateDebutReservation
        {
            get
            {
                return dateDebutReservation;
            }

            set
            {
                if (value > this.DateFinReservation) { throw new ArgumentException("ATTENTION, la date de de début doit etre inférieur à la adte du début de reservation !"); }
                dateDebutReservation = value;
            }
        }

        public DateTime DateFinReservation
        {
            get
            {
                return dateFinReservation;
            }

            set
            {
                if(value<this.DateDebutReservation) { throw new ArgumentException("ATTENTION, la date de fin doit etre supérieur à la date du début de reservation !"); }
                dateFinReservation = value;
            }
        }

        public decimal MoantantReservation
        {
            get
            {
                return moantantReservation;
            }

            set
            {
                moantantReservation = value;
            }
        }

        public string ForfaitKm
        {
            get
            {
                return this.forfaitKm;
            }

            set
            {
                if(string.IsNullOrEmpty(value)) { throw new ArgumentException("ATTENTION, le forfaitKM ne doit pas etre ni nulle ni vide !"); }
                this.forfaitKm = value;
            }
        }

        public Reservation(int numReservation, int numAssurance, int numClient, DateTime dateReservation, DateTime dateDebutReservation, DateTime dateFinReservation, decimal moantantReservation, string forfaitKm)
        {
            NumReservation = numReservation;
            NumAssurance = numAssurance;
            NumClient = numClient;
            DateReservation = dateReservation;
            DateDebutReservation = dateDebutReservation;
            DateFinReservation = dateFinReservation;
            MoantantReservation = moantantReservation;
            ForfaitKm = forfaitKm;
        }
    }
}
