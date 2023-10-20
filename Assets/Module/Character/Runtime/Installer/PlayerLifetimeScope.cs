using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class PlayerLifetimeScope : LifetimeScope
{
    [SerializeField]
    private GameObject player;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterBuildCallback(container =>
        {
            container.Resolve<PlayerFlowController>().Initialize();
        });

        builder.RegisterComponent(player.GetComponent<PlayerInput>());

        builder.RegisterComponent(player.GetComponent<PlayerMove>());

        builder.RegisterComponent(player.GetComponent<PlayerAnimation>());

        builder.RegisterComponent(player.GetComponent<PlayerFight>());

        builder.Register<PlayerFlowController>(Lifetime.Singleton);

        builder.Register<PlayerInputPresenter>(Lifetime.Singleton);
        builder.Register<PlayerMovePresenter>(Lifetime.Singleton);
        builder.Register<PlayerAnimationPresenter>(Lifetime.Singleton);
        builder.Register<PlayerFightPresenter>(Lifetime.Singleton);
        
    }
}
