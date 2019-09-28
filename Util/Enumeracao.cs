using System.ComponentModel;

namespace Util
{
    public sealed class Enumeracao
    {
        public enum ESituacao
        {
            [Description("Ativo")]
            Ativo = 1,
            [Description("Cancelado")]
            Cancelado = 2,
            [Description("Finalizado")]
            Finalizado = 3
        }

        public enum ETipoDeAcao
        {
            Desmarcar = 0,
            Marcar = 1,
        }
    }
}
