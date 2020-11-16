using Dock.UI.Site.Models;

namespace Dock.UI.Site.Data
{
    public class PedidoRepository: IPedidoRepository
    {
        public Pedido ObterPedido()
        {
            return new Pedido();
        }
    }

    public interface IPedidoRepository
    {
        Pedido ObterPedido();
    }
}
