package improbable.apps

import improbable.math.Vector3d
import improbable.natures.{Pirate, Terrain}
import improbable.papi.world.AppWorld
import improbable.papi.worldapp.WorldApp
import scala.util.Random

import improbable.utils._
import scala.concurrent.duration._

class WorldInitialiser(val world: AppWorld) extends WorldApp {

  final val MAX_SHIPS = 20  // total number of pirates to spawn
  final val DISTANCE_BETWEEN_SHIPS = 15 // distance between pirates on spawn, not too close together
  final val SPAWN_DELAY = 200   // msecs (5 pirates spawned per second)

  // Code here will be run when the simulated world starts.
  world.entities.spawnEntity(Terrain(Vector3d.zero))

  var numberOfPirates = 0

  // Wait for 200 milliseconds before spawning a pirate
  world.timing.every(SPAWN_DELAY milliseconds) {

    if (numberOfPirates < MAX_SHIPS) {
      // Get the position of the pirate in a spiral
      val position = SpawnerUtils.getSpiralSpawnPosition (numberOfPirates, DISTANCE_BETWEEN_SHIPS)

      // Spawn the pirate at the position in the world
      world.entities.spawnEntity(Pirate(position))

      // Increment the number of spawned pirates
      numberOfPirates += 1
    }
  }

}