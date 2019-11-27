# Beacon
A multi-device distributed system for making distress calls when a person is in danger.

## Research Phase
Beacon is an idea that came to me on a recent trip to Mexico. I had been worried about the risk of drug cartels and kidnappings that have been increasing in the country over recent years.

I imagined a scenario where there was no time to make a phone call etc. What if you had a device, such as a bracelet (could be anything, but somewhere on your body) with a button, that when pressed, could send a distress call to one or more people/organizations notifying them that your life is in danger. The distress call could contain all your details along with any data collected by the hardware, such as latitude & longitude from GPS, etc.

I haven't started this project yet, and I may never start it, depending on time I have available. But, if anyone would be interested in working on such a project (which I feel could potentially save lives) then do get in touch!

## Notes & Ideas

-  The core should be non-hardware specific and generic.

- Hardware: should be small (inconspicuous), waterproof, durable and long-lasting battery. It could also have hardware 'swarm' that could link together and for situations where one piece of hardware is missing or not appropriate for the activity.

- Support for multiple inputs (HR, GPS, buttons, etc).

- Ability to 'ping' server with small data packets and receive commands (i.e. low bandwidth and high availability). Perhaps via roaming/radio signals or some sort of high availability (globally) network - can GPS satellites be used? Pings could be, say every 20 minutes and be logged on a server. Perhaps goal would be less than 1kb per ping/command. Could use what3words for location info.

- The device could be paired with a smartphone via Bluetooth, allowing the phone to use it's GPS and roaming data to send distress calls.

- Built-in commands such as distress (critical, 'in-fear', concerned), inform contacts of the plan change, inform contacts that all is ok, etc.

- Built-in AI for things like unusual HR patterns or unexpected locations. That can prompt the user to confirm they are OK.

- Separate (secure) app for configuring each 'beacon'. Things like your details, next of kin, setting up expected locations/dates, activities/times (e.g. running), people/authorities to contact in an emergency, who can see your stats and under what circumstances.

- How about some sort of warning system to users that based on their current location and known danger areas that they shouldn't go there (perhaps a traffic light system of green/safe, amber/some risk and red/dangerous).
