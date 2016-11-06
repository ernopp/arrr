package improbable.natures

import improbable.behaviours.{ClientSideAuthorityBehaviour, DecrementHealthBehaviour, DelegatePlayerControlsToClient, TrackScoreBehaviour}
import improbable.corelib.natures.{BaseNature, NatureApplication, NatureDescription}
import improbable.corelib.util.EntityOwnerDescriptor
import improbable.corelibrary.transforms.TransformNature
import improbable.papi.engine.EngineId
import improbable.papi.entity.EntityPrefab
import improbable.papi.entity.behaviour.EntityBehaviourDescriptor
import improbable.ship.{Health, PlayerControls}

object Player extends NatureDescription {

  override val dependencies = Set[NatureDescription](BaseNature, TransformNature)

  import improbable.behaviours.DelegateCombatToFSimBehaviour
  import improbable.ship.HitByCannonball
  import improbable.ship.Score

  override def activeBehaviours: Set[EntityBehaviourDescriptor] = {
    Set(
      descriptorOf[ClientSideAuthorityBehaviour],
      descriptorOf[DelegatePlayerControlsToClient],
      descriptorOf[DecrementHealthBehaviour],
      descriptorOf[DelegateCombatToFSimBehaviour],
      descriptorOf[TrackScoreBehaviour]
    )
  }

  def apply(clientId: EngineId): NatureApplication = {
    application(
      states = Seq(
        EntityOwnerDescriptor(Some(clientId)),
        PlayerControls(targetSpeed = 0, targetSteering = 0),
        Health(100),
        HitByCannonball(),
        Score(0)
      ),
      natures = Seq(
        BaseNature(EntityPrefab("PlayerShip")),
        TransformNature()
      )
    )
  }
}
