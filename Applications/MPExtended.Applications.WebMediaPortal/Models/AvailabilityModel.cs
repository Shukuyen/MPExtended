﻿#region Copyright (C) 2011-2012 MPExtended
// Copyright (C) 2011-2012 MPExtended Developers, http://mpextended.github.com/
// 
// MPExtended is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MPExtended is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MPExtended. If not, see <http://www.gnu.org/licenses/>.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPExtended.Applications.WebMediaPortal.Code;
using MPExtended.Libraries.Service;

namespace MPExtended.Applications.WebMediaPortal.Models
{
    public class AvailabilityModel
    {
        public bool TAS { get; set; }
        public bool MAS { get; set; }

        public bool Movies { get; set; }
        public bool TVShows { get; set; }
        public bool Music { get; set; }

        public bool Authentication { get; set; }

        public AvailabilityModel()
        {
            Reload();
        }

        public void Reload()
        {
            Authentication = Configuration.Authentication.Enabled;

            TAS = Connections.Current.HasTASConnection;
            MAS = Connections.Current.HasMASConnection;

            var msd = Connections.Current.HasMASConnection ? Connections.Current.MAS.GetServiceDescription() : null;
            Movies = MAS && msd.DefaultMovieLibrary != 0;
            TVShows = MAS && msd.DefaultTvShowLibrary != 0;
            Music = MAS && msd.DefaultMusicLibrary != 0;
        }
    }
}