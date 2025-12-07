***JWSysWrap***
---
**JWSysWrap** is designed <span style=color:Red>*from the start*</span> to grow over time.<br/>
As new requirements pop up, new System Objects will be wrapped.

The overwhelming purpose for JWSysWrap is to facilitate Dependency Injection in support of Unit Testing.
Allowing the Developer to Mock items which may otherwise be difficult to Mock.

For instance, TimeSpan implements several interfaces:
public struct TimeSpan : IComparable, IComparable<TimeSpan>, IEquatable<TimeSpan>, IFormattable

Yet it does not implement an interface which would allow you to Mock it directly, such as <span style=color:Red>ITimeSpan</span>.

JWWrap creates and implements this interface in the <span style=color:Red>TimeSpanWrap</span> Class.