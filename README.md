# FriendlyTime (.NET)
C#/.NET extension to convert a DateTime object into a human readable string such as "1 hour ago", "Yesterday", etc.

## Usage

    using FriendlyTime;
    
    DateTime dateTime = DateTime.Now;
    string readable = dateTime.ToFriendlyDateTime();
    
    // Returns: "Just Now"
    
    
## Development

FriendlyTime is written in C# 6 making use of the new string interpolation features.

Please use the included StyleCop ruleset when making changes to the source.
