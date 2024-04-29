using UnityEngine;
using Core.Gameplay;
using System.Collections;
using Core.Audio;
public abstract class InteractableObject : MonoBehaviour, Interactable
{    
    public Entity entity;
    public InteractionType interactionType;
    public AudioPlayer audioPlayer;
    public GameObject GameObject => gameObject;
    public Entity Entity => entity;

    public InteractionType InteractionType => interactionType;

    public virtual void Contact()
    {
        Global.contact.Value = this;
        DialogController.Instance.Name.text = entity.displayName;
        DialogController.Instance.Text.text = "";
    }

    public virtual void ContactLost()
    {
        Global.contact.Value = null;
        DialogController.Instance.Name.text = "";
        DialogController.Instance.Text.text = "";
    }

    public virtual void Interact()
    {
        InteractionClue.Hide();
        Debug.Log($"{this.name} Interacting");
        StartCoroutine(PlaySfx());
    }

    private IEnumerator PlaySfx()
    {
        if (audioPlayer != null)
        {
            if (Entity.sfx != null)
            {
                audioPlayer.Play(Entity.sfx);
                yield return new WaitWhile(() => audioPlayer.IsPlaying);
            }
            else if (InteractionType != null && InteractionType.audioClip != null)
            {
                audioPlayer.Play(InteractionType.audioClip);
                yield return new WaitWhile(() => audioPlayer.IsPlaying);
            }
        }
    }
}
