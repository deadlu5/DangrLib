# BitValueExtensions Class
 

Provides extension methods for the <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a>`enum` and <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> arrays.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Simulation.Types.BitValueExtensions<br />
**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static class BitValueExtensions
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public NotInheritable Class BitValueExtensions
```

**C++**<br />
``` C++
[ExtensionAttribute]
public ref class BitValueExtensions abstract sealed
```

The BitValueExtensions type exposes the following members.


## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_And">And(BitValue, BitValue, Boolean)</a></td><td>
Logical Ands the specified values if they ar binary. Returns <a href="T_Dangr_Simulation_Types_BitValue">Error</a> if either value is <a href="T_Dangr_Simulation_Types_BitValue">Error</a> . If either value is <a href="T_Dangr_Simulation_Types_BitValue">Floating</a> , then the *ignoreFloating* parameter determines if the result should be <a href="T_Dangr_Simulation_Types_BitValue">Error</a> ( `false` ) or pass through the other value ( `true` ).</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_And_1">And(BitValue[], BitValue[], BitValue[], Boolean)</a></td><td>
Performs a bitwise logcial <a href="M_Dangr_Simulation_Types_BitValueExtensions_And">And(BitValue, BitValue, Boolean)</a> of the specified values and stores the result in the array specified by output. Output can be equal to one of the inputs.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_Increment">Increment</a></td><td>
Increments the specified *value* and stores the result in the array specified by output. Overflows will wrap. Output can be equal to value.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_Invert">Invert(BitValue)</a></td><td>
Inverts the specified *value* if it is binary. The *value* is the same for non binary values.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_Invert_1">Invert(BitValue[], BitValue[])</a></td><td>
Inverts the specified *value* and stores the result in the array specified by output. Output can be equal to value.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_IsEqual">IsEqual</a></td><td>
Determines whether the specified <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> arrays are equal.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_Negate">Negate</a></td><td>
Negates the specified *value* and stores the result in the array specified by output. Output can be equal to value.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_Or">Or(BitValue, BitValue, Boolean)</a></td><td>
Logical Ors the specified values if they ar binary. Returns <a href="T_Dangr_Simulation_Types_BitValue">Error</a> if either value is <a href="T_Dangr_Simulation_Types_BitValue">Error</a> . If either value is <a href="T_Dangr_Simulation_Types_BitValue">Floating</a> , then the *ignoreFloating* parameter determines if the result should be <a href="T_Dangr_Simulation_Types_BitValue">Error</a> ( `false` ) or pass through the other value ( `true` ).</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_Or_1">Or(BitValue[], BitValue[], BitValue[], Boolean)</a></td><td>
Performs a bitwise logcial <a href="M_Dangr_Simulation_Types_BitValueExtensions_Or">Or(BitValue, BitValue, Boolean)</a> of the specified values and stores the result in the array specified by output. Output can be equal to one of the inputs.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_PrintString">PrintString</a></td><td>
Returns a string representation of a <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> array.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_Pull">Pull</a></td><td>
Pulls the specified *value* using the given <a href="T_Dangr_Simulation_Types_PullBehavior">PullBehavior</a> and stores the result in the array specified by output. Output can be equal to value.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_Xor">Xor(BitValue, BitValue, Boolean)</a></td><td>
Logical Xors the specified values if they ar binary. Returns <a href="T_Dangr_Simulation_Types_BitValue">Error</a> if either value is <a href="T_Dangr_Simulation_Types_BitValue">Error</a> . If either value is <a href="T_Dangr_Simulation_Types_BitValue">Floating</a> , then the *ignoreFloating* parameter determines if the result should be <a href="T_Dangr_Simulation_Types_BitValue">Error</a> ( `false` ) or pass through the other value ( `true` ).</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_BitValueExtensions_Xor_1">Xor(BitValue[], BitValue[], BitValue[], Boolean)</a></td><td>
Performs a bitwise logcial <a href="M_Dangr_Simulation_Types_BitValueExtensions_Xor">Xor(BitValue, BitValue, Boolean)</a> of the specified values and stores the result in the array specified by output. Output can be equal to one of the inputs.</td></tr></table>&nbsp;
<a href="#bitvalueextensions-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />