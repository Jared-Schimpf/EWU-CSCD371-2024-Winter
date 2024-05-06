using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

namespace Logger;
//if it uses reference semantics it should be immutable
// if it uses value semantics it can be mutable <-

/*
fullname should be mutable since there may be cases where we want to change it's individual fields without reassigning a whole Fullname variable: 
for example: a legal name change, last name change from marriage, adding optional middle name field later


since different entities can have the same name and there's nothing ensuring that they will point to the same fullname reference when they shave the same values,
there is no reason for fullname to be a reference type. Even if there was something ensuring that fullnames with the same fields pointed to the same reference,
we wouldn't WANT two different entities sharing the same reference in the first place, because if one entity changed a field in the reference it would 
erroniously affect all of the entity classes that share that name.

*/
public record struct FullName(string First, string Last, string? Middle = ""){
    public string First {get; set;} = First ?? throw new ArgumentNullException(nameof(FullName));
    public string Last {get; set;} = Last ?? throw new ArgumentNullException(nameof(FullName));
    public string Middle {get; set;} = Middle ?? "";
    
  /*  public FullName(string first, string? middle, string last){
        First = first;
        Middle = middle ?? "";
        Last = last;
    }
*/

}