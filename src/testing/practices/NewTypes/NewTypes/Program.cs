using System.Collections.Generic;
using NewTypes.Pets;

List<IPet> pets = new List<IPet>{
    new Cat(),
    new Dog(),
    new Bird()
};

foreach (var pet in pets)
{
    Console.WriteLine(pet.TalkToOwner());
}