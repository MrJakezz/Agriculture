using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Team
    {
        public int TeamID { get; set; }
        public string PersonName { get; set; }
        public string PersonTitle { get; set; }
        public string PersonImageUrl { get; set; }
        public string PersonFacebookUrl { get; set; }
        public string PersonInstagramUrl { get; set; }
        public string PersonTwitterUrl { get; set; }
        public string PersonWebsiteUrl { get; set; }
    }
}
