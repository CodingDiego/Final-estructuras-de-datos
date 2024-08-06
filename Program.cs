
namespace Final_estructuras_de_datos {
    internal class Program {
        public static void Main(string[] args) {
            var pedidos = LeerPedidos("Pedidos.txt");
            pedidos = OrdenarPedidos(pedidos);

            AltaPedido(pedidos, new Pedido { NumeroModelo = 1, NumeroConcesionaria = 10, CantidadPedida = 5 });
            BajaPedido(pedidos, 1, 10);
            ModificarPedido(pedidos, new Pedido { NumeroModelo = 1, NumeroConcesionaria = 10, CantidadPedida = 10 });
            ListarPedidos(pedidos);

            EscribirPedidos("Pedidos.txt", pedidos);

            GenerarReporte(pedidos, new List<StockModelo>(), new List<StockPieza>(), new List<ComposicionVehiculo>());
        }

        public static List<Pedido> LeerPedidos(string filepath) {
            var pedidos = new List<Pedido>();
            foreach(var line in File.ReadLines(filepath)) {
                var parts = line.Split(',');
                pedidos.Add(new Pedido {
                    NumeroModelo = int.Parse(parts[0]),
                    NumeroConcesionaria = int.Parse(parts[1]),
                    CantidadPedida = int.Parse(parts[2])
                });
            }
            return pedidos;
        }
        public static void GenerarReporte(List<Pedido> pedidos, List<StockModelo> stockModelos, List<StockPieza> stockPiezas, List<ComposicionVehiculo> composicionVehiculos) {
            Console.WriteLine("Reporte de Stock y Pedidos:");
            Console.WriteLine("----------------------------");

            foreach(var pedido in pedidos) {
                var modelo = stockModelos.FirstOrDefault(m => m.NumeroModelo == pedido.NumeroModelo);
                if(modelo != null) {
                    Console.WriteLine($"Modelo {pedido.NumeroModelo}:");
                    Console.WriteLine($"  Stock Anual: {modelo.StockAnual}");
                    Console.WriteLine($"  Cantidad Pedida: {pedido.CantidadPedida}");
                    Console.WriteLine();
                }
            }
        }
        public static List<StockModelo> LeerStockModelo(string filePath) {
            var stockModelos = new List<StockModelo>();
            foreach(var line in File.ReadLines(filePath)) {
                var parts = line.Split(',');
                if(parts.Length >= 3 && int.TryParse(parts[0], out int numeroModelo)) {
                    stockModelos.Add(new StockModelo {
                        NumeroModelo = numeroModelo,
                        Descripcion = parts[1],
                        StockAnual = int.Parse(parts[2])
                    });
                }
            }
            return stockModelos;
        }
        public static List<Pedido> OrdenarPedidos(List<Pedido> pedidos) {
            return pedidos.OrderBy(p => p.NumeroModelo).ThenBy(p => p.NumeroConcesionaria).ToList();
        }
        public static void EscribirPedidos(string filepath, List<Pedido> pedidos) {
            using(var writer = new StreamWriter(filepath)) {
                foreach(var pedido in pedidos) {
                    writer.WriteLine($"{pedido.NumeroModelo}, {pedido.NumeroConcesionaria}, {pedido.CantidadPedida}");
                }
            }
        }
        public static void AltaPedido(List<Pedido> pedidos, Pedido nuevoPedido) {
            pedidos.Add(nuevoPedido);
        }
        public static List<StockPieza> LeerStockPieza(string filepath) {
            var stockPiezas = new List<StockPieza>();
            foreach(var line in File.ReadLines(filepath)) {
                var parts = line.Split(',');
                if(parts.Length >= 3 && int.TryParse(parts[0], out int numeroPieza)) {
                    stockPiezas.Add(new StockPieza {
                        NumeroPieza = numeroPieza,
                        Decripcion = parts[1],
                        StockAnual = int.Parse(parts[2])
                    });
                }
            }
            return stockPiezas;
        }
        public static List<ComposicionVehiculo> LeerComposicionVehiculo(string filePath) {
            var composicionVehiculos = new List<ComposicionVehiculo>();
            foreach(var line in File.ReadLines(filePath)) {
                var parts = line.Split(',');
                if(parts.Length >= 3 && int.TryParse(parts[0], out int numeroModelo)) {
                    composicionVehiculos.Add(new ComposicionVehiculo {
                        NumeroModelo = numeroModelo,
                        NumeroPieza = int.Parse(parts[1]),
                        CantidadUsar = int.Parse(parts[2])
                    });
                }
            }
            return composicionVehiculos;
        }
        public static void EscribirComposicionVehiculo(string filePath, List<ComposicionVehiculo> composicionVehiculos) {
            using(var writer = new StreamWriter(filePath)) {
                foreach(var composicion in composicionVehiculos) {
                    writer.WriteLine($"{composicion.NumeroModelo},{composicion.NumeroPieza},{composicion.CantidadUsar}");
                }
            }
        }

        public static void EscribirStockPieza(string filePath, List<StockPieza> stockPiezas) {
            using(var writer = new StreamWriter(filePath)) {
                foreach(var pieza in stockPiezas) {
                    writer.WriteLine($"{pieza.NumeroPieza},{pieza.Decripcion},{pieza.StockAnual}");
                }
            }
        }

        public static void ModificarPedido(List<Pedido> pedidos, Pedido pedidoModificado) {
                var pedido = pedidos.FirstOrDefault(p => p.NumeroModelo == pedidoModificado.NumeroModelo && p.NumeroConcesionaria == pedidoModificado.NumeroConcesionaria);
                if(pedido != null) {
                    pedido.CantidadPedida = pedidoModificado.CantidadPedida;
                }

            }

        public static void ListarPedidos(List<Pedido> pedidos) {
                foreach(var pedido in pedidos) {
                    Console.WriteLine($"Modelo: {pedido.NumeroModelo}, Concesionaria: {pedido.NumeroConcesionaria}, Cantidad: {pedido.CantidadPedida}");
                }
            }

        public static void BajaPedido(List<Pedido> pedidos, int numeroModelo, int numeroConcesionaria) {
            var pedido = pedidos.FirstOrDefault(p => p.NumeroModelo == numeroModelo && p.NumeroConcesionaria == numeroConcesionaria);
            if(pedido != null) {
                pedidos.Remove(pedido);
            }
        }
    }
}
