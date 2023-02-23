using System.Collections.Generic;
using TeamApplication.Models;

namespace TeamApplication.Controllers
{
    internal class UpdateStat
    {
        public IEnumerable<PlayerDto> PlayersOptions { get; set; }
        public StatDto SelectedStat { get; set; }
    }
}