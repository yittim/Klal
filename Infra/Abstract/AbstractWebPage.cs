using Infra.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Abstract
{
    public abstract class AbstractWebPage
    {
        protected readonly AbstractWebActions driver;

        public AbstractWebPage(AbstractWebActions driver)
        {
            this.driver = driver;
        }
    }
}
