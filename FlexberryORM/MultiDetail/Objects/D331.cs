﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIS.CDLIB
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// D331.
    /// </summary>
    // *** Start programmer edit section *** (D331 CustomAttributes)

    // *** End programmer edit section *** (D331 CustomAttributes)
    [AutoAltered()]
    [ICSSoft.STORMNET.NotStored(false)]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class D331 : IIS.CDLIB.D
    {
        
        private IIS.CDLIB.D33 fD33;
        
        // *** Start programmer edit section *** (D331 CustomMembers)

        // *** End programmer edit section *** (D331 CustomMembers)

        
        /// <summary>
        /// мастеровая ссылка на шапку IIS.CDLIB.D33.
        /// </summary>
        // *** Start programmer edit section *** (D331.D33 CustomAttributes)

        // *** End programmer edit section *** (D331.D33 CustomAttributes)
        [Agregator()]
        [NotNull()]
        [PropertyStorage(new string[] {
                "D33"})]
        public virtual IIS.CDLIB.D33 D33
        {
            get
            {
                // *** Start programmer edit section *** (D331.D33 Get start)

                // *** End programmer edit section *** (D331.D33 Get start)
                IIS.CDLIB.D33 result = this.fD33;
                // *** Start programmer edit section *** (D331.D33 Get end)

                // *** End programmer edit section *** (D331.D33 Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (D331.D33 Set start)

                // *** End programmer edit section *** (D331.D33 Set start)
                this.fD33 = value;
                // *** Start programmer edit section *** (D331.D33 Set end)

                // *** End programmer edit section *** (D331.D33 Set end)
            }
        }
    }
    
    /// <summary>
    /// Detail array of D331.
    /// </summary>
    // *** Start programmer edit section *** (DetailArrayDetailArrayOfD331 CustomAttributes)

    // *** End programmer edit section *** (DetailArrayDetailArrayOfD331 CustomAttributes)
    public class DetailArrayOfD331 : ICSSoft.STORMNET.DetailArray
    {
        
        // *** Start programmer edit section *** (IIS.CDLIB.DetailArrayOfD331 members)

        // *** End programmer edit section *** (IIS.CDLIB.DetailArrayOfD331 members)

        
        /// <summary>
        /// Construct detail array.
        /// </summary>
        /// <summary>
        /// Returns object with type D331 by index.
        /// </summary>
        /// <summary>
        /// Adds object with type D331.
        /// </summary>
        public DetailArrayOfD331(IIS.CDLIB.D33 fD33) : 
                base(typeof(D331), ((ICSSoft.STORMNET.DataObject)(fD33)))
        {
        }
        
        public IIS.CDLIB.D331 this[int index]
        {
            get
            {
                return ((IIS.CDLIB.D331)(this.ItemByIndex(index)));
            }
        }
        
        public virtual void Add(IIS.CDLIB.D331 dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }
    }
}