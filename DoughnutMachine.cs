﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace Huszar_Otilia_Lab2
{
    class DoughnutMachine
    {
        // campuri aferente clasei doughnut machine
        private DoughnutType mFlavor;
        private System.Collections.ArrayList mDoughnuts = new System.Collections.ArrayList();

        public DoughnutType Flavor
        {
            get { return mFlavor; }
            set { mFlavor = value; }
        }

        public Doughnut this[int Index]
        {
            get { return (Doughnut)mDoughnuts[Index]; }
            set { mDoughnuts[Index] = value; }
        }

        // constructori
        public DoughnutMachine()
        {
            InitializeComponent();
        }

        // metode
        public void MakeDoughnuts(DoughnutType dFlavor)
        {
            Flavor = dFlavor;
            switch(Flavor)
            {
                case DoughnutType.Glazed: Interval = 3; break;
                case DoughnutType.Sugar: Interval = 2; break;
                case DoughnutType.Lemon: Interval = 5; break;
                case DoughnutType.Chocolate: Interval = 7; break;
                case DoughnutType.Vanilla: Interval = 4; break;
            }
            doughnutTimer.Start();
        }

        // evenimete, timere
        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;

        DispatcherTimer doughnutTimer;
        
        public bool Enabled
        {
            set { doughnutTimer.IsEnabled = value; }
        }
        public int Interval
        {
            set { doughnutTimer.Interval = new TimeSpan(0, 0, value); }
        }

        private void InitializeComponent()
        {
            this.doughnutTimer = new DispatcherTimer();
            this.doughnutTimer.Tick += new System.EventHandler(this.doughnutTimer_Tick);
        }

        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(this.Flavor);
            mDoughnuts.Add(aDoughnut);
            DoughnutComplete();
        }
    }

    class Doughnut
    {
        private DoughnutType mFlavor;
        private float mPrice = .50F;
        private readonly DateTime mTimeOfCreation;

        public DoughnutType Flavor 
        { 
            get { return mFlavor; } 
            set { mFlavor = value; } 
        }
        public float Price 
        { 
            get { return mPrice; } 
            set { mPrice = value; } 
        }
        public DateTime TimeOfCreation 
        { 
            get { return mTimeOfCreation; } 
        }

        public Doughnut(DoughnutType aFlavor)
        {
            mTimeOfCreation = DateTime.Now;
            mFlavor = aFlavor;
        }
    }

    public enum DoughnutType
    {
        Glazed,
        Sugar,
        Lemon,
        Chocolate,
        Vanilla
    }
}
