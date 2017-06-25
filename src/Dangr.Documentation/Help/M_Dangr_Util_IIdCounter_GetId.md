# IIdCounter.GetId Method 
 

Gets the next available ID.

**Namespace:**&nbsp;<a href="N_Dangr_Util">Dangr.Util</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
ulong GetId()
```

**VB**<br />
``` VB
Function GetId As ULong
```

**C++**<br />
``` C++
unsigned long long GetId()
```


#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">UInt64</a><br />The next available Id.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="T_Dangr_Util_IdCounterOutOfRangeException">IdCounterOutOfRangeException</a></td><td>If the next value would be larger than the max value of this <a href="T_Dangr_Util_IdCounter">IdCounter</a> .</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Util_IIdCounter">IIdCounter Interface</a><br /><a href="N_Dangr_Util">Dangr.Util Namespace</a><br />