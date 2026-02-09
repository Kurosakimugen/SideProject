<h1>Quests</h1>

<?php foreach ($sagas as $sagaSlug => $saga): ?>
    <section>
        <h2><?= htmlspecialchars($saga['name']) ?></h2>

        <ul>
            <?php foreach ($saga['quests'] as $questSlug => $quest): ?>
                <li>
                    <a href="/lore/quests/<?= $sagaSlug ?>/<?= $questSlug ?>">
                        <?= htmlspecialchars($quest['name']) ?>
                    </a>
                </li>
            <?php endforeach; ?>
        </ul>
    </section>
<?php endforeach; ?>
