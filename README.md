Use Case 1 :
It provides comprehensive details on the properties of the Schedule class, including Flight Number, Departure City, Arrival city, Day, and IsFlightLoaded. The documentation also emphasizes that there is no requirement to load Orders, as the focus is solely on displaying schedules that are not loaded.

Use Case 2 :
According to the specifications, priority is given to the Order class, and it is recommended to load it into the Plane/Flight based on priorities. Consequently, the Order class will include properties such as Code, Destination, Priority, and Schedule. While the orders in the JSON file are already arranged by priorities, it is advisable to further ensure proper ordering based on priority.
