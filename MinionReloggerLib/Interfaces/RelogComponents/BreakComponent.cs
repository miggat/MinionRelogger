/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Alpha -- https://github.com/Vipeax/MinionRelogger   *
*  Copyright (C) 2013, Robert van den Boorn                                  *
*                                                                            *
*  This program is free software: you can redistribute it and/or modify      *
*   it under the terms of the GNU General Public License as published by     *
*   the Free Software Foundation, either version 3 of the License, or        *
*   (at your option) any later version.                                      *
*                                                                            *
*   This program is distributed in the hope that it will be useful,          *
*   but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the            *
*   GNU General Public License for more details.                             *
*                                                                            *
*   You should have received a copy of the GNU General Public License        *
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.    *
*                                                                            *
******************************************************************************/

using System;
using MinionReloggerLib.Interfaces.Objects;

namespace MinionReloggerLib.Interfaces.RelogComponents
{
    public class BreakComponent : IRelogComponent
    {
        public bool Check(Account account)
        {
            throw new NotImplementedException();
        }

        public IRelogComponent DoWork(Account account)
        {
            throw new NotImplementedException();
        }

        public bool IsReady(Account account)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account)
        {
            throw new NotImplementedException();
        }

        public bool PostWork(Account account)
        {
            throw new NotImplementedException();
        }
    }
}