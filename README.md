Historically, inside the NServiceBus installer, we shipped a tool called XsdGenerator.exe. XsdGenerator is a command line tool that will generate an XSD file using an assembly of messages as input.  This is for the case where you don't want to directly distribute your messages assembly, but would rather have consumers build their own.

The XsdGenerator.exe tool is now deprecated. The code for this tool has been moved to this repository. It will no longer be shipped as part of any NServiceBus tooling.

If you still want to use XsdGenerator.exe feel free to use the code inside this repository to compile a copy.

If, for any reason, the above options do not meet your specific requirements please don't hesitate to contacts about this decision.