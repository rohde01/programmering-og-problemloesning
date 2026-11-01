open simulate

//make 10 drones
let drone1 = drone ((1, 5), 2, (5, 99), "drone1")
let drone2 = drone ((14, 20), 1, (18, 30), "drone2")
let drone3 = drone ((4, 2), 7, (39, 15), "drone3")
let drone4 = drone ((87, 14), 17, (75, 55), "drone4")
let drone5 = drone ((14, 20), 4, (18, 30), "drone5")
let drone6 = drone ((8, 2), 13, (35, 18), "drone6")
let drone7 = drone ((45, 50), 8, (5, 10), "drone7")
let drone8 = drone ((14, 20), 6, (18, 30), "drone8")
let drone9 = drone ((15, 46), 7, (23, 13), "drone9")
let drone10 = drone ((13, 5), 15, (55, 45), "drone10")

//AddDrone test
let airspace1 = airspace()
airspace1.add drone1
airspace1.add drone2
airspace1.add drone3
airspace1.add drone4
airspace1.add drone5
airspace1.add drone6
airspace1.add drone7
airspace1.add drone8
airspace1.add drone9
airspace1.add drone10

//getDrones test
printfn "Active drones before flight: %A" (airspace1.getDrones())

//fly test
drone1.fly

//FlyDrones and collide test x10 to simulate 10 seconds of flight
airspace1.FlyDrones()
airspace1.collide()
airspace1.FlyDrones()
airspace1.collide()
airspace1.FlyDrones()
airspace1.collide()
airspace1.FlyDrones()
airspace1.collide()
airspace1.FlyDrones()
airspace1.collide()
airspace1.FlyDrones()
airspace1.collide()
airspace1.FlyDrones()
airspace1.collide()
airspace1.FlyDrones()
airspace1.collide()
airspace1.FlyDrones()
airspace1.collide()
airspace1.FlyDrones()
airspace1.collide()

//collide test
printfn "Active drones after 10 second flight (collide test): %A" (airspace1.getDrones())

//getPosition test
printfn "getPosition test: %A" drone1.getPosition

//DroneDist test
printfn "DroneDist test: %A" (airspace1.DroneDist drone1 drone5)

//AtDestination test
printfn "AtDestination test:" 
drone2.AtDestination

//Assert test
Assert.asserttest ("drone10.AtDestination?") drone10.AtDestination () (=)