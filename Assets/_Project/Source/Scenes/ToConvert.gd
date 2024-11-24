func try_attack(enemy_targets: Array, ally_targets: Array):
	attacks_performed += 1
	var moral_degradation_chance = (attacks_performed - 10) * 0.04
	if randf() < moral_degradation_chance:
		if randf() < moral_degradation_chance:
			change_morale(-4)
		else :
			change_morale(-2)

	if character.health_regeneration > 0:
		change_health(character.health_regeneration)

	match character.attack_type:
		"heal":
			if ally_targets.size() > 0:
				var weakest_character
				var lowest_health = 1.0
				for ally in ally_targets:
					if ally.get_relative_health() < lowest_health:
						weakest_character = ally
						lowest_health = ally.get_relative_health()
				if weakest_character and lowest_health < 1.0:
					var damage_range: = character.get_damage_range()
					var heal_amount: int = randi_range(damage_range.x, damage_range.y)
					var t = create_tween()
					t.tween_callback(weakest_character.change_health.bind(heal_amount)).set_delay(0.2)
					t.tween_interval(0.2)
					t.tween_callback(attack_finished.emit)
					$VisualCharacter.active(t)
					sounds.attack()
					if heal_amount <= 0:
						var floating_text_heal_fail: = FloatingText.new(weakest_character, "0", 20, Color.GREEN_YELLOW.darkened(0.2), false)
						Data.event("event.pop_number", floating_text_heal_fail)
						vfx.miss(weakest_character)
					else :
						vfx.attack(weakest_character)
				else :
					create_tween().tween_callback(attack_finished.emit).set_delay(0.1)
				return 
			else :
				create_tween().tween_callback(attack_finished.emit).set_delay(0.1)
		"area":
			if enemy_targets.size() > 0:
				var damage_range: = character.get_damage_range()
				var dist = 10 if is_hero else -10
				var t = $VisualCharacter.lunge(dist)
				$VisualCharacter.active(t)
				sounds.attack()
				vfx.impacted.connect(attack_all.bind(enemy_targets, - randi_range(damage_range.x, damage_range.y)), CONNECT_ONE_SHOT)
				vfx.attack(enemy_targets)
				return 
			else :
				create_tween().tween_callback(attack_finished.emit).set_delay(0.1)
		"melee":
			if enemy_targets.size() > 0:
				enemy_targets.shuffle()
				for column in range(0, 3):
					for t in enemy_targets:
						if t.character.column == column and randf() < t.character.blockage:
							attack(t)
							return 

				attack(enemy_targets.pick_random())
				return 
			else :
				create_tween().tween_callback(attack_finished.emit).set_delay(0.1)
		"ranged":

			if enemy_targets.size() > 0:
				enemy_targets.shuffle()
				for column in range(0, 3):
					for t in enemy_targets:
						if t.character.column == column and randf() < t.character.blockage * 0.4:
							attack(t)
							return 

				attack(enemy_targets.pick_random())
				return 
			else :
				create_tween().tween_callback(attack_finished.emit).set_delay(0.1)
		_:
			if enemy_targets.size() > 0:
				attack(enemy_targets.pick_random())
				return 
			else :
				create_tween().tween_callback(attack_finished.emit).set_delay(0.1)


	$VisualCharacter.lie_down()

func attack_all(targets: Array, damage: int):
	for target in targets:
		var r: = randf()
		if r < 1.0 - (character.hit_chance - target.character.evasion):
			if r < 1.0 - character.hit_chance:
				target.miss()
			else :
				target.evade()
		else :
			target.character.last_attacker_name = character.name
			target.change_health(damage)
	create_tween().tween_callback(attack_finished.emit).set_delay(0.1)

func attack(target):
	var damage_range: = character.get_damage_range()
	var c: Callable
	var r: = randf()
	if r < 1.0 - (character.hit_chance - target.character.evasion):
		if r < 1.0 - character.hit_chance:
			c = target.miss
		else :
			c = target.evade
		change_morale(-1)
		sounds.miss()
		vfx.miss(target)
	elif randf() < character.crit_chance && !character.has_trait("curse_no_luck"):
		c = target.change_health.bind(-2 * damage_range.y, true)
		target.character.last_attacker_name = character.name
		change_morale(2)
		sounds.crit()
		vfx.crit(target)
	else :
		c = target.change_health.bind( - randi_range(damage_range.x, damage_range.y))
		target.character.last_attacker_name = character.name
		change_morale(1)
		sounds.attack()
		vfx.attack(target)

	if not vfx.has_signal("impacted"):
		var dist = 20 if is_hero else -20
		var t = $VisualCharacter.lunge(dist, c)
		$VisualCharacter.active(t)
		t.tween_callback(attack_finished.emit)
	else :
		var dist = 20 if is_hero else -20
		var t = $VisualCharacter.lunge(dist)
		$VisualCharacter.active(t)
		t.tween_callback(attack_finished.emit)
		vfx.impacted.connect(c, CONNECT_ONE_SHOT)


func change_health(change: int, critical: = false):
	if change == 0:
		return 

	if change < 0:
		change = min(0, change + character.damage_reduction)

	if change < 0:
		$VisualCharacter.got_hit(-3 if is_hero else 3)
	else :
		var dist = -4 if is_hero else 4
		$VisualCharacter.lunge(dist)


	if change < 0 && - change >= character.health && character.health != 1:
		if character.has_trait("unyielding"):
			$VisualCharacter.say(TraitEffects.UNYIELDING_LINES.pick_random())
			change = - character.health + 1

	var health_compare_value = character.health if change > 0 else character.health + change
	character.health = clamp(character.health + change, 0, character.max_health)
	if health_hit_tween:
		health_hit_tween.kill()
	health_hit_tween = create_tween()
	health_hit_tween.tween_property( % HealthLoss, "scale:x", get_relative_health(), 0.4).set_delay(0.2)
	changed_health.emit()
	if character.health <= 0:
		died.emit()
	elif change == 0:
		var floating_text_data_block: = FloatingText.new(self, "blocked", 20, Color.DIM_GRAY, false)
		sounds.block()
		Data.event("event.pop_number", floating_text_data_block)
		return 
	elif is_hero:
		var morale_hit: = 0

		if critical:
			morale_hit += 4

		if health_compare_value <= character.max_health * 0.15:
			morale_hit += 10
		elif health_compare_value <= character.max_health * 0.28:
			morale_hit += 6
		elif health_compare_value <= character.max_health * 0.5:
			morale_hit += 4
		elif health_compare_value <= character.max_health * 0.7:
			morale_hit += 2
		elif health_compare_value <= character.max_health * 0.85:
			morale_hit += 1

		if change < 0:
			change_morale( - morale_hit)
		else :
			change_morale(floor(morale_hit * 0.8))
	var color = (Color.BROWN if is_hero else Color.CORNSILK) if change < 0 else Color.GREEN_YELLOW
	if critical:
		color = Color.DARK_ORANGE
	var size: int = 28 if not critical else 34
	var number_string
	if not is_hero and change < 0:
		number_string = "%d" % abs(change)
	else :
		number_string = "%+d" % change
	var floating_text_data: = FloatingText.new(self, number_string, size, color, critical)
	Data.event("event.pop_number", floating_text_data)
	update()