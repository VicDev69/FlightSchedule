﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 
namespace Flights {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class FLIGHT {
        
        private string airlineField;
        
        private byte flightNumberField;
        
        private string commercialFlightNumberField;
        
        private string fromField;
        
        private string toField;
        
        private string sTDField;
        
        private string sTAField;
        
        private sbyte maxPaxField;
        
        private sbyte maxCargoField;
        
        private byte repetativeField;
        
        private byte isMasterField;
        
        private string beginDateField;
        
        private string endDateField;
        
        private uint daysField;
        
        private sbyte payloadField;
        
        /// <remarks/>
        public string Airline {
            get {
                return this.airlineField;
            }
            set {
                this.airlineField = value;
            }
        }
        
        /// <remarks/>
        public byte FlightNumber {
            get {
                return this.flightNumberField;
            }
            set {
                this.flightNumberField = value;
            }
        }
        
        /// <remarks/>
        public string CommercialFlightNumber {
            get {
                return this.commercialFlightNumberField;
            }
            set {
                this.commercialFlightNumberField = value;
            }
        }
        
        /// <remarks/>
        public string From {
            get {
                return this.fromField;
            }
            set {
                this.fromField = value;
            }
        }
        
        /// <remarks/>
        public string To {
            get {
                return this.toField;
            }
            set {
                this.toField = value;
            }
        }
        
        /// <remarks/>
        public string STD {
            get {
                return this.sTDField;
            }
            set {
                this.sTDField = value;
            }
        }
        
        /// <remarks/>
        public string STA {
            get {
                return this.sTAField;
            }
            set {
                this.sTAField = value;
            }
        }
        
        /// <remarks/>
        public sbyte MaxPax {
            get {
                return this.maxPaxField;
            }
            set {
                this.maxPaxField = value;
            }
        }
        
        /// <remarks/>
        public sbyte MaxCargo {
            get {
                return this.maxCargoField;
            }
            set {
                this.maxCargoField = value;
            }
        }
        
        /// <remarks/>
        public byte Repetative {
            get {
                return this.repetativeField;
            }
            set {
                this.repetativeField = value;
            }
        }
        
        /// <remarks/>
        public byte IsMaster {
            get {
                return this.isMasterField;
            }
            set {
                this.isMasterField = value;
            }
        }
        
        /// <remarks/>
        public string BeginDate {
            get {
                return this.beginDateField;
            }
            set {
                this.beginDateField = value;
            }
        }
        
        /// <remarks/>
        public string EndDate {
            get {
                return this.endDateField;
            }
            set {
                this.endDateField = value;
            }
        }
        
        /// <remarks/>
        public uint Days {
            get {
                return this.daysField;
            }
            set {
                this.daysField = value;
            }
        }
        
        /// <remarks/>
        public sbyte Payload {
            get {
                return this.payloadField;
            }
            set {
                this.payloadField = value;
            }
        }
    }
}
