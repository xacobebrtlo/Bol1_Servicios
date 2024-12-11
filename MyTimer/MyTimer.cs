using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejer6
{
    public class MyTimer   //El prograMA DEBE FINALIZAR
    {
        public delegate void Delegado();
        public int interval;
        public static bool running = false;
        private readonly Object l = new Object();
        public Delegado delegado;

        public MyTimer(Delegado d)
        {
            delegado = d;
            Thread hilo = new Thread(gestor);
            hilo.IsBackground = true; 
            hilo.Start();
           
        }

        public void gestor()
        {
            while (true)
            {
                Thread.Sleep(interval);
                lock (l)
                {
                    if (!running)
                    {
                       // running = false;
                        Monitor.Wait(l);
                        //run();
                        //Thread.Sleep(interval);
                    }
                        delegado();
                }
            }
        }
        public void run()
        {

            if (!running)
            {
                lock (l)
                {
                    Monitor.Pulse(l);

                    running = true;
                }

            }
        }
        public void pause()
        {
            lock (l)
            {

                if (running)
                {
                    running = false;
                }
                
            }
        }
    }
}
