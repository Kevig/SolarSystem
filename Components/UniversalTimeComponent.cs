using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalTimeComponent : MonoBehaviour {
	// Units of time definitions
	public float _second;
	public float second {
		get => this._second;
		set => this._second = value;
	}
	
	public float _minute;
	public float minute {
		get => this._minute;
		set => this._minute = value;
	}

	public float _hour;
	public float hour {
		get => this._hour;
		set => this._hour = value;
	}

	public float _day;
	public float day {
		get => this._day;
		set => this._day = value;
	}

	public float _week;
	public float week {
		get => this._week;
		set => this._week = value;
	}

	public float _month;
	public float month {
		get => this._month;
		set => this._month = value;
	}

	public float _year;
	public float year {
		get => this._year;
		set => this._year = value;
	}

	// Time Values

	public float _elapsedTime;
	public float elapsedTime {
		get => this._elapsedTime;
		set => this._elapsedTime = value;
	}

	public float _elapsedSeconds;
	public float elapsedSeconds {
		get => this._elapsedSeconds;
		set => this._elapsedSeconds = value;
	}
	
	public float _elapsedMinutes;
	public float elapsedMinutes {
		get => this._elapsedMinutes;
		set => this._elapsedMinutes = value;
	}
	
	public float _elapsedHours;
	public float elapsedHours {
		get => this._elapsedHours;
		set => this._elapsedHours = value;
	}
	
	public float _elapsedDays;
	public float elapsedDays {
		get => this._elapsedDays;
		set => this._elapsedDays = value;
	}
	
	public float _elapsedWeeks;
	public float elapsedWeeks {
		get => this._elapsedWeeks;
		set => this._elapsedWeeks = value;
	}
	
	public float _elapsedMonths;
	public float elapsedMonths {
		get => this._elapsedMonths;
		set => this._elapsedMonths = value;
	}
	
	public float _elapsedYears;
	public float elapsedYears {
		get => this._elapsedYears;
		set => this._elapsedYears = value;
	}
	
	public void Awake()	{
		this.elapsedTime = 0f;
		this._day = 1f;
		this._hour = this._day / 24f;
		this._minute = this._hour / 60f;
		this._second = this._minute / 60f;
		this._week = this._day * 7f;
		this._month = this._day * 30f;
		this._year = this._day * 365f;
	}

	private void updateElapsedSeconds() { this.elapsedSeconds = this.elapsedTime / this.second; }
	private void updateElapsedMinutes() { this.elapsedMinutes = this.elapsedTime / this.minute; }
	private void updateElapsedHours() { this.elapsedHours = this.elapsedTime / this.hour; }
	private void updateElapsedDays() { this.elapsedDays = this.elapsedTime / this.day; }
	private void updateElapsedWeeks() { this.elapsedWeeks = this.elapsedTime / this.week; }
	private void updateElapsedMonths() { this.elapsedMonths = this.elapsedTime / this.month; }
	private void updateElapsedYears() { this.elapsedYears = this.elapsedTime / this.year; }

	public void updateTimeValues() {
		updateElapsedSeconds();
		updateElapsedMinutes();
		updateElapsedHours();
		updateElapsedDays();
		updateElapsedWeeks();
		updateElapsedMonths();
		updateElapsedYears();
	}

}
