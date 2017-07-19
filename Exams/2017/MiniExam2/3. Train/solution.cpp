#include<iostream>
#include<vector>
#include<set>
#include<algorithm>

int main() {
	int N, M, L;
	std::cin >> N >> M >> L;

	std::vector<std::pair<int, int>> intervals(N);

	for(auto& x : intervals)
		std::cin >> x.first >> x.second;

	std::sort(intervals.begin(), intervals.end());

	std::multiset<int> boarded;

	int result = 0;
	for(auto& x : intervals) {
		while(!boarded.empty()) {
			auto it = boarded.begin();
			if(*it > x.first) break;
			boarded.erase(it);
			++result;
		}
		boarded.insert(x.second);
		if(boarded.size() > (unsigned)M)
			boarded.erase(std::prev(boarded.end()));
	}

	result += boarded.size();
	std::cout << result << '\n';
}
