const TargetRadius = {
	Outer: 10,
	Middle: 5,
	Inner: 1
};

const Scores = {
	Outside: 0,
	Outer: 1,
	Middle: 5,
	Inner: 10
};

function FindScore(radius) {
	if (TargetRadius.Inner >= radius) {
		return Scores.Inner;
	}
	else if (TargetRadius.Middle >= radius) {
		return Scores.Middle;
	}
	else if (TargetRadius.Outer >= radius) {
		return Scores.Outer;
	}
	else {
		return Scores.Outside;
	}
}

export const score = (xCoordinate, yCoordinate) => {
	if (xCoordinate !== 0 && yCoordinate !== 0) {
		return FindScore(Math.sqrt(xCoordinate ** 2 + yCoordinate ** 2));
	}
	else if (xCoordinate !== 0) {
		return FindScore(Math.abs(xCoordinate));
	}
	else {
		return FindScore(Math.abs(yCoordinate));
	}
};
