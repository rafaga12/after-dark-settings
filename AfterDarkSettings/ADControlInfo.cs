
/*
Copyright (c) 2022 Rafaga Systems (Rafael Garay Perez)

This file is part of After Dark Settings.

After Dark Settings is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

After Dark Settings is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with After Dark Settings. If not, see <https://www.gnu.org/licenses/>. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterDarkSettings
{
    class ADControlInfo
    {   
        byte[] resourceData;

        public ADControl ControlType
        {
            get
            {
                ushort Value = BitConverter.ToUInt16(resourceData, 0);
                return (ADControl)Value;
            }
        }

        public string ControlName
        {
            get
            {
                string Value = Encoding.UTF8.GetString(resourceData, 2, 20);
                return Value;
            }
        }

        public ushort Steps
        {
            get
            {
                ushort Value = BitConverter.ToUInt16(resourceData, 22);
                return Value;
            }
        }

        public ushort DefaultValue
        {
            get
            {
                ushort Value = BitConverter.ToUInt16(resourceData, 24);
                return Value;
            }
        }

        public string Suffix
        {
            get
            {
                string Value = "";
                if (resourceData.Length > 32)
                {
                    Value = Encoding.UTF8.GetString(resourceData, 32, 16);
                }
                return Value;
            }
        }

        public ushort MinValue
        {
            get
            {
                ushort Value = 0;
                if (resourceData.Length > 48)
                {
                    Value = BitConverter.ToUInt16(resourceData, 48);
                }
                return Value;
            }
        }

        public ushort MaxValue
        {
            get
            {
                ushort Value = 0;
                if (resourceData.Length > 50)
                {
                    Value = BitConverter.ToUInt16(resourceData, 50);
                }
                return Value;
            }
        }
        
        //For Combobox, Text Slider
        public string[] Values
        {
            get
            {
                List<string> ReturnValues = new List<string>();
                int startPosition = 32;
                int dataSize = 16;
                if (resourceData.Length > startPosition)
                {
                    for (int i = startPosition; i < (startPosition + (Steps * dataSize)); i += dataSize)
                    {
                        ReturnValues.Add(Encoding.UTF8.GetString(resourceData, i, dataSize));
                    }
                }
                return ReturnValues.ToArray();
            }
        }

        public ushort[] Thresholds
        {
            get
            {
                List<ushort> ReturnValues = new List<ushort>();
                int startPosition = (32 + (Steps * 16));
                int dataSize = 2;
                if (resourceData.Length > startPosition)
                {
                    for (int i = startPosition; i < (startPosition + (Steps * dataSize)); i += dataSize)
                    {
                        ReturnValues.Add(BitConverter.ToUInt16(resourceData, i));
                    }
                }
                return ReturnValues.ToArray();
            }
        }

        public ADControlInfo(byte[] ResourceData)
        {
            resourceData = ResourceData;
        }
    }
}
