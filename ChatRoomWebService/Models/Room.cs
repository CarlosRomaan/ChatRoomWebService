//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatRoomWebService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.ChatMessage = new HashSet<ChatMessage>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdState { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Description { get; set; }
    
        public virtual cState cState { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatMessage> ChatMessage { get; set; }
    }
}
