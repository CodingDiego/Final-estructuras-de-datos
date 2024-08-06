using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_estructuras_de_datos {

    class Pedido {
        public int NumeroModelo {
            get; set;
        }

        public int NumeroConcesionaria {
            get; set;
        }

        public int CantidadPedida {
            get; set;
        }
    }

    class StockModelo {
        public int NumeroModelo {
            get; set;
        }

        public string Descripcion {
            get; set;
        }

        public int StockAnual {
            get; set;
        }
    }

    public class StockPieza {
        public int NumeroPieza {
            get; set;
        }

        public string Decripcion {
            get; set;
        }

        public int StockAnual {
            get; set;
        }

    }

    public class ComposicionVehiculo {
        public int NumeroModelo {
            get;set;
        }

        public int NumeroPieza {
            get; set;
        }

        public int CantidadUsar {
            get; set;
        }

    }
}
