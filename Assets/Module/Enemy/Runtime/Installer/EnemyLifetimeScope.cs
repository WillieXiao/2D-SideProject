using VContainer;
using VContainer.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifetimeScope : LifetimeScope
{
    [SerializeField]
    private GameObject enemyGameObject;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterBuildCallback(container =>
        {
            container.Resolve<EnemyAIController>().Initialize();
        });

        builder.RegisterComponent<EnemyMove>(enemyGameObject.GetComponent<EnemyMove>());
        builder.RegisterComponent<EnemyAnimation>(enemyGameObject.GetComponent<EnemyAnimation>());
        builder.RegisterComponent<EnemyDetect>(enemyGameObject.GetComponent<EnemyDetect>());
        builder.RegisterComponent<EnemyFight>(enemyGameObject.GetComponent<EnemyFight>());


        builder.Register<EnemyAIController>(Lifetime.Singleton);
        builder.Register<EnemyPatrolState>(Lifetime.Singleton);
        builder.Register<EnemyChaseState>(Lifetime.Singleton);
        builder.Register<EnemyAttackState>(Lifetime.Singleton);
        builder.Register<EnemyFightState>(Lifetime.Singleton);


        builder.Register<EnemyMovePresenter>(Lifetime.Singleton);
        builder.Register<EnemyAnimationPresenter>(Lifetime.Singleton);
        builder.Register<EnemyDetectPresenter>(Lifetime.Singleton);
        builder.Register<EnemyFightPresenter>(Lifetime.Singleton);

    }
}
